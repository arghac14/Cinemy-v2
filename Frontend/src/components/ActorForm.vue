<template>
    <div class="actor-form">
     <Form ref="formValidate" :model="formValidate" :rules="ruleValidate" :label-width="80">
        <FormItem required label="Name:" prop="name">
            <Input v-model="formValidate.name" placeholder="Enter Actor's Name..."></Input>
        </FormItem>
       
        <FormItem required label="DOB:">
            <FormItem required prop="dob">
                <DatePicker type="date" placeholder="Select date" v-model="formValidate.dob"></DatePicker>
            </FormItem>
               
        </FormItem>
        <FormItem required label="Gender:" prop="gender">
            <RadioGroup v-model="formValidate.gender">
                <Radio label="male">Male</Radio>
                <Radio label="female">Female</Radio>

            </RadioGroup>
        </FormItem>
        
        <FormItem required label="Bio:" prop="bio">
            <Input v-model="formValidate.bio" type="textarea" :autosize="{minRows: 1,maxRows: 3}" placeholder="Enter Bio..."></Input>
        </FormItem>
        <FormItem>
            <Button id="sm-button" type="primary" @click="actorFormSubmit('formValidate')" long>Submit</Button>
        </FormItem>
    </Form>   
    </div>
</template>
<script>
import actorAPIService from "../services/actorAPIService";
import { mapActions } from "vuex";
    export default {
        data () {
            return {
                formValidate: {
                    name: '',
                    gender: '',
                    dob: '',
                    bio: ''
                },
                ruleValidate: {
                    name: [
                        { required: true, min: 1, message: 'The name cannot be empty', trigger: 'blur' }
                    ],
                    bio: [
                        { required: true, message: 'Please enter the bio', trigger: 'blur' },
                        { type: 'string', min: 1, message: 'Introduce no less than 4 words', trigger: 'blur' }
                    ]
                }
            }
        },
        methods: {
            ...mapActions(["getAllActors"]),
            actorFormSubmit (data) {
                this.$refs[data].validate((valid) => {
                    if (valid) {
                        this.$Message.success('Success!');
                        let actorData = {
                          name: this.formValidate.name,
                          gender: this.formValidate.gender,
                          dob: this.formValidate.dob,
                          bio: this.formValidate.bio
                        };
                        actorAPIService
                        .add(actorData)
                        .then(()=>{
                            this.getAllActors();
                            this.$emit('modalHasClosed', false);
                        })
                    } else {
                        this.$Message.error('Failed!');
                    }
                    
                })
            }
        }
    }
</script>
<style scoped>
#sm-button{
  border-width: 0px;
  color: var(--black);
  font-weight: bold;
  border-radius: 4px;
  background: var(--yellow);
  box-shadow:  5px 5px 11px #3d0404,
             -5px -5px 11px #f31010;             
}


</style>