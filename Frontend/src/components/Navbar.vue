<template>
    <div id="nav">
    <Layout>
        <Menu mode="horizontal" class="nav" width="auto">
            <MenuItem>
                <div id="nav-logo">
                    <img id="imdb-logo" src="../assets/cinemy.png">
                </div>
            </MenuItem>
         <div id="navbar">
            <MenuItem name="1">
                <router-link to="/">
                    <div id="nav-menu">
                        <lord-icon
                        src="https://cdn.lordicon.com//tdxypxgp.json"
                        trigger="loop"
                        colors="primary:#D3E615"
                        id="movie-icon">
                       </lord-icon>
                        Movies
                    </div>
                </router-link>
            </MenuItem>
            
            <!-- <MenuItem name="2">
                <router-link to="/movieform">
                    <div id="nav-menu">
                        <lord-icon
                        src="https://cdn.lordicon.com//rzrkjbrm.json"
                        trigger="loop"
                        colors="primary:#D3E615"
                        id="add-movie-icon">
                       </lord-icon>
                        Add Movie
                    </div>
                </router-link>
            </MenuItem> -->
            <MenuItem name="3">
                <router-link to="/actors">
                    <div id="nav-menu">
                        <lord-icon
                        src="https://cdn.lordicon.com//rzrkjbrm.json"
                        trigger="loop"
                        colors="primary:#D3E615"
                        id="add-movie-icon">
                       </lord-icon>
                        Actors
                    </div>
                </router-link>
            </MenuItem>
            <MenuItem name="4">
                <router-link to="/producers">
                    <div id="nav-menu">
                        <lord-icon
                        src="https://cdn.lordicon.com//rzrkjbrm.json"
                        trigger="loop"
                        colors="primary:#D3E615"
                        id="add-movie-icon">
                       </lord-icon>
                        Directors
                    </div>
                </router-link>
            </MenuItem>
            <MenuItem name="5" v-if="this.logggedInUserName">
                    <div id="nav-menu-side-button">
                        Welcome back, {{this.logggedInUserName}}! ❤️ <Button id="sm-button" :size="small" type="primary" @click="Logout()"> Log out </Button>
                    </div>
            </MenuItem>
             </div>
            <MenuItem name="sidebar" id="sidebar">
                <Button @click="openDrawer = true" id="hamburger-icon">
                    <div id="hamburger-bar"></div>
                    <div id="hamburger-bar"></div>
                    <div id="hamburger-bar"></div>
                </Button>
                <Drawer placement="left" :closable="true" v-model="openDrawer" id="drawer">
                     <div id="sidebar-logo">
                        <img id="imdb-logo" src="../assets/imdb.png">
                     </div>
                     <hr><br>
                    <MenuItem name="1">
                        <router-link to="/">
                            <div id="nav-menu-1">
                                Movies
                            </div>
                        </router-link>
                    </MenuItem>
                    <MenuItem name="1">
                        <router-link to="/">
                            <div id="nav-menu">
                                Movies
                            </div>
                        </router-link>
                    </MenuItem>
                    <MenuItem name="2">
                        <router-link to="/actors">
                            <div id="nav-menu">
                                Actors
                            </div>
                        </router-link>
                    </MenuItem>
                     <MenuItem name="3">
                        <router-link to="/producers">
                            <div id="nav-menu">
                                Directors
                            </div>
                        </router-link>
                    </MenuItem><br>
                    <MenuItem name="4" v-if="this.logggedInUserName">
                    <div id="nav-menu-side-button">
                        <Button id="sm-button" :size="small" type="primary" @click="Logout()"> Log out </Button>
                    </div>
            </MenuItem>
                </Drawer>
            </MenuItem>
        </Menu>
        <div slot="trigger"></div>
    </Layout>
    </div>
</template>
<script>
import { mapState } from "vuex";
export default {
    data(){
        return {
            openDrawer: false
        };
    },
    computed: {
        ...mapState([
      'userName',
    ]),
        ...mapState({
            logggedInUserName: () => {
                return localStorage.getItem("userName");
            },
    })
    },
    methods: {
        Logout() {
            this.$store.state.userName = '';
            this.$store.state.isAdminUser = 0;
            localStorage.clear();
            this.$router.push("/login");
        }
    }
}
</script>
<style scoped>

::v-deep .ivu-menu-item:nth-child(4) {
    float: right !important;
    color: white !important;
    font-size: 20px;
}

.nav{
    background-color: var(--black);
}

#nav-menu{
    color: var(--yellow);
    font-size: 20px;
}

#navbar{
    display: block;
}

::v-deep .ivu-drawer-content{
    background-color: var(--red) !important;
    color: var(--yellow);
    box-shadow: inset 11px -11px 22px #360303,
            inset -11px 11px 22px #d60b0b;
}
::v-deep .ivu-icon-ios-close{
    color: yellow !important;
}

#sidebar{
    float:right;
    display: none;
}

#drawer{
    box-shadow: 5px 5px 10px #670505,
             -5px -5px 10px #a50909;
}

#nav-menu-1 {
    display: none;    
}

#sm-button{
  border-width: 0px;
  color: var(--black);
  font-weight: bold;
  border-radius: 4px;
  background: var(--yellow);       
  margin-bottom: 1%;     
}

#sidebar-logo{
    text-align: center;
}

@media (max-width: 900px) {
    #sidebar {
        display: block;
    }
    #navbar {
        display: none;
    }
}

#imdb-logo{
    padding-top: 10px;
    height: 50px;
    width: 100px;
}

#movie-icon{
    width:40px;
    height:40px;
}
#add-movie-icon{
     width:50px;
    height:50px;
    padding-bottom:10px
}
#hamburger-bar{
    width: 27px;
    height: 4px;
    background-color: var(--yellow);
    margin: 6px 0;
}

#hamburger-icon{
    background-color: var(--black);
    border-color: var(--black);
}

</style>