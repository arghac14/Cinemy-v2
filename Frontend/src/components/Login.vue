<template>
 <center>
    <br><img src="../assets/cinemy.png" height="100rem" width="120rem"><br>
<div class="auth">
   <div id="header">
      <h1> 
          <lord-icon id="movie-header-icon"
          src="https://cdn.lordicon.com//tdxypxgp.json" trigger="loop" colors="primary:#D3E615">
          </lord-icon> 
          Sign in <br>
        </h1><hr>
      </div><br>
    <Form ref="formCustom" :model="formCustom" :rules="ruleCustom" :label-width="80">
        <FormItem label="Username" prop="username">
            <Input type="text" v-model="formCustom.username"></Input>
        </FormItem>
        <FormItem label="Password" prop="password">
            <Input type="password" v-model="formCustom.password"></Input>
        </FormItem>
        <br>
        <FormItem>
            <Button id="button"  type="warning" @click="handleSubmit('formCustom')">Submit</Button>
        </FormItem>
        
    </Form>
    <hr><br>
    <div class="yellow-text">Already have an account? <a href="/signup">Sign up</a></div>
</div>
</center>
</template>
<script>
import userAPIService from "../services/userAPIService";
    export default {
        data () {
            const validateUsername = (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('Please enter your username'));
                } else {
                    if (this.formCustom.username !== '') {
                        this.$refs.formCustom.validateField('username');
                    }
                    callback();
                }
            };
            const validatePassCheck = (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('Please enter your password'));
                } else if (value !== this.formCustom.password) {
                    callback(new Error('Please enter your password'));
                } else {
                    callback();
                }
            };
            const validateEmail = (rule, value, callback) => {
                if (!value) {
                    return callback(new Error('Email cannot be empty'));
                } else {
                    callback();
                }
            };
            
            return {
                formCustom: {
                    password: '',
                    username: '',
                    email: ''
                },
                ruleCustom: {
                    password: [
                        { validator: validatePassCheck, trigger: 'blur' }
                    ],
                    username: [
                        { validator: validateUsername, trigger: 'blur' }
                    ],
                    email: [
                        { validator: validateEmail, trigger: 'blur' }
                    ]
                }
            }
        },
        methods: {
            handleSubmit (name) {
                this.$refs[name].validate((valid) => {
                    if (valid) {
                        var requestData = {
                            userName: this.formCustom.username,
                            password: this.formCustom.password,
                            email: this.formCustom.email
                        }
                        userAPIService
                        .getUser(requestData)
                        .then((res)=>{
                            if(res){
                                var userName = res.data.data.userName;
                                var accessToken = res.data.data.accessToken;
                                var isAdmin = res.data.data.isAdmin;
                                localStorage.setItem('accessToken', accessToken);
                                localStorage.setItem('isAdminUser', isAdmin);
                                localStorage.setItem('userName', userName);
                                this.$store.state.userName = userName;
                                this.$store.state.isAdminUser = isAdmin;
                                this.$Message.success('Welcome!');
                                this.$router.push("/");
                            }
                            else{
                                this.$Message.error('Invalid Credentials!');
                            }
                        })
                        .catch((e)=>{
                            console.log(e);
                            this.$Message.error('Something went wrong!');
                        });
                    } else {
                        this.$Message.error('Something went wrong!');
                    }
                })
            },
            handleReset (name) {
                this.$refs[name].resetFields();
            }
        }
    }
</script>

<style scoped>
::v-deep .ivu-input {
    width: 50% !important;
}
.yellow-text{
    color: rgb(248,158,8);
}
::v-deep .ivu-switch-checked {
    border-color: rgb(207, 25, 12) !important;
    background-color: rgb(248,158,8) !important;
    color: rgb(207, 25, 12) !important;
}
.auth{
  width: 600px;
  height: 100%;
  padding: 1rem;
  padding-top: 2rem;
  padding-left: 2rem;
  padding-right: 2rem;
  border-radius: 23px;
  background: #860707;
  box-shadow: inset 10px 10px 20px #540404,
                inset -10px -10px 20px #b80a0a;
}
@media only screen and (max-width: 440px) {
  img{
    margin-left: 55% !important;
  }
}
@media only screen and (max-width: 560px) {
  img{
    margin-left: 35% !important;
  }
}
@media only screen and (max-width: 380px) {
  img{
    margin-left: 72% !important;
  }
}

#button{
  border-width: 0px;
  color: var(--black);
  font-size: 15px;
  font-weight: bold;
  height: 40px;
  border-radius: 7px;
  width: 80%;
  margin-right: 15%;
  background: var(--yellow);
  box-shadow:  5px 5px 11px #3d0404,
             -5px -5px 11px #f31010;             
}
::v-deep .ivu-form .ivu-form-item-label {
    text-align: left !important;
    vertical-align: middle !important;
    float: left !important;
    font-size: 14px !important;
    color: rgb(248,158,8) !important;
    line-height: 1 !important;
    padding: 10px 12px 10px 10px !important;
    padding-left: 12%!important;
    box-sizing: border-box !important;
}
h1{
    color: rgb(248,158,8) !important;
    padding-bottom: 15px;
}
</style>