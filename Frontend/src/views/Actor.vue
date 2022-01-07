<template>
  <div class="actor">
    <Navbar/>
    <div id="header">
      <br>
      <center>
      <h1> 
          <lord-icon id="actor-header-icon"
          src="https://cdn.lordicon.com//tdxypxgp.json" trigger="loop" colors="primary:#D3E615">
          </lord-icon> 
          Actors
        </h1>
      </center><hr>
      </div>
    <br>
    <ActorList/>
    
  </div>
</template>

<script>
import ActorList from "../components/ActorList.vue";
import Navbar from "../components/Navbar.vue";
export default {
  data(){
    return{
      
    }
  },
  components:{
    ActorList,
    Navbar
  }
};
</script>
<style scoped>

#header{
  color: var(--yellow);
  box-shadow:  8px 8px 12px #360303,
             -8px -8px 12px #d60b0b;
}
#actor-header-icon{
    width: 50px;
    height: 50px;
    padding-bottom: 5px;
}
</style>