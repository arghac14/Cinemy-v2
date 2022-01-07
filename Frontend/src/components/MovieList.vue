<template>
  <div class="movie-list">
    <div v-if="movies.length==0" id="no-data">No data available!</div>
    <div id="movie-cards-wrapper">
      <Row id="movie-list-row">
        <Col :xs="24" :sm="12" :md="8" :lg="8" id="movie-card-col" v-for="(movie, index) in movies" :key="index">
          <MovieCard :movie="movie" :index= "index"></MovieCard>
        </Col>
      </Row>
    </div>
  </div>
</template>

<script>
import MovieCard from "./MovieCard.vue";
import {mapState} from 'vuex';
export default{
  data(){
    return{
       
    }
  },
  beforeCreate() {
    this.$store.dispatch("getAllMovies");
  },
  computed:{
    ...mapState([
      'movies',
    ]),
  },
  components:{
    MovieCard
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
#movie-cards-wrapper{
  padding: 10px;
  margin: 10px;
}
#movie-list-row{
  padding: 10px;
}
#movie-card-col{
  padding:10px;
}
#no-data {
  color: whitesmoke;
  font-size: 30px;
  text-align: center;
}
</style>
