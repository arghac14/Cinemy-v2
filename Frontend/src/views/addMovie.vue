<template>
  <div class="addMovie">
    <Navbar/>
     <div id="header">
      <br>
      <center>
      <h1>
          Add Movie
      </h1>
      </center><hr>
    </div><br> 
    <MovieForm/>

 </div>
</template>

<script>
import MovieForm from '../components/MovieForm.vue';
import Navbar from "../components/Navbar.vue";
    export default {
        data () {
            return {
              
            }
        },
        components:{
          MovieForm,
          Navbar
        }
    }
</script>

<style scoped>
#header{
  color: var(--yellow)
}
</style>