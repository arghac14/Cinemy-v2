<template>
  <div class="movie">
    <Navbar/>
    <div id="header">
      <br>
      <!-- <h2 class="profile">  Welcome back {{name}}!</h2><br><hr> -->
      <center>
        
      <h1> 
          <lord-icon id="movie-header-icon"
          src="https://cdn.lordicon.com//tdxypxgp.json" trigger="loop" colors="primary:#D3E615">
          </lord-icon> 
          Movies <br>
          <Button v-if="this.isAdminPortal" id="sm-button" :size="small" type="primary" @click="addMovie()">
            Add 
            <lord-icon id="icon"
                src="https://cdn.lordicon.com//mecwbjnp.json"
                trigger="loop"
                colors="primary:#000000,secondary:#000000">
            </lord-icon>
          </Button> <br v-if="isAdminPortal">
          
        </h1>
      </center><hr>
      </div>
    <br>
    <MovieList/>
    
  </div>
</template>

<script>
import MovieList from "../components/MovieList.vue";
import { mapState } from "vuex";
import Navbar from "../components/Navbar.vue";
export default {
  data(){
    return{
    }
  },
  components:{
    MovieList,
    Navbar
  },
  computed: {
        ...mapState({
          isAdminPortal: () => {
                return localStorage.getItem("isAdminUser");
            },
  })
  },
  methods: {
    addMovie() {
      this.$router.push('/Movie/add');
    }
  }
};
</script>
<style scoped>
.profile {
  text-align: center;
  color: white;

}
#sm-button{
  border-width: 0px;
  color: var(--black);
  font-weight: bold;
  border-radius: 4px;
  background: var(--yellow);
  box-shadow:  5px 5px 11px #3d0404,
             -5px -5px 11px #f31010;        
  margin-bottom: 1%;     
}
#header{
  color: var(--yellow);
  box-shadow:  8px 8px 12px #360303,
             -8px -8px 12px #d60b0b;
}
#movie-header-icon{
    width: 50px;
    height: 50px;
    padding-bottom: 5px;
}
</style>