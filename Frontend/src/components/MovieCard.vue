<template>
    <div class="movie-detail-card">
        <Card id="movie-card" :bordered="false">
            <img v-if="!movie.poster" id="movie-poster" src="../assets/no-image-available.jpg"/><br><hr>
            <img v-if="movie.poster" id="movie-poster" :src="movie.poster"/><br><hr>
            <p id="movie-title"> {{movie.name}} 
            </p> 
            <div id="buttons" v-if="this.isAdminPortal">
                <Button id="button" @click="deleteMovie(movie.id)"> 
                Delete <lord-icon id="icon" src="https://cdn.lordicon.com//rivoakkk.json" colors="primary:#D3E615" trigger="hover"></lord-icon>
                </Button>
                <Button id="button" @click="updateMovie(movie.id)"> 
                Edit <lord-icon id="icon" src="https://cdn.lordicon.com//wloilxuq.json" colors="primary:#D3E615" trigger="hover"></lord-icon>
                </Button>
            </div> 
            <hr><br> 
            <p class="movie-details">Release Year: <span class="movie-data">{{movie.yearOfRelease}}</span></p>
            <p class="movie-details">Genre: <span class="movie-data">{{genreList(index)}}</span></p>
            <p class="movie-details">Director: <span class="movie-data">{{movie.producer.name}}</span></p>
            <p class="movie-details">Actors: <span class="movie-data">{{actorList(index)}}</span></p>
            <p class="movie-details">Plot: <span class="movie-data">{{movie.plot}}</span></p>
            <br>
        </Card> 
    </div>
</template>
<script>
import {mapState, mapActions} from 'vuex';
import movieAPIService from "../services/movieAPIService";
export default {
    props:{
        movie:{
            type: Object
        },
        index: {
            type: Number
        }
    },
    computed:{
    ...mapState([
      'movies',
    ]),
    ...mapState({
          isAdminPortal: () => {
                return localStorage.getItem("isAdminUser");
            },
  })
    },
     methods:{
    ...mapActions(["getAllMovies"]),
    genreList(id){   
      var movieList = this.$store.state.movies;
        var genres = [];
        movieList.forEach(movie=>{
          var cogenres = [];
          movie.genre.forEach(g=>{
            cogenres.push(g.name);
          });
          genres.push(cogenres.join(', '));
        })
        return genres[id];
    },
     actorList(id) {
        var actors = [];
        this.$store.state.movies.forEach(movie=>{
          var coactors = [];
          movie.actor.forEach(a=>{
            coactors.push(a.name);
          });
          actors.push(coactors.join(', '));
        })
        return actors[id];
    },
    updateMovie(id) {
      this.$router.push(`Movie/${id}/edit`);
    },
    deleteMovie(id) {
      movieAPIService.delete(id).then(() => this.getAllMovies());
    },
  }
}
</script>
<style scoped>
#movie-card{
  width: 100%;
  height: 100%;
  background-color: var(--red);
  border-radius: 25px;
  background: var(--red);
  box-shadow:  8px 8px 12px #360303,
             -8px -8px 12px #d60b0b;
}
#movie-title{
  font-size: 20px;
  font-weight: bolder;
  color: var(--yellow);

}
.movie-details{
  font-size: 20px;
  font-weight: bold;
  color: var(--yellow);
}
.movie-data{
  font-size: 18px;
  font-weight: lighter;
  color: whitesmoke;
  text-align: justify;
}
#movie-poster{
  width: 100%;
  height: 200px;
  border-radius: 15px 15px 0 0;
  box-shadow: 8px 8px 12px #490505;
  font-size: 40px;
  text-align: center;
  color: whitesmoke;
}
#button{
  padding: 2px;
  margin-top: 10px;
  float: right;
  text-align: right;
  background-color: var(--red);
  border: 1px;
  border-color: var(--black);
  border-radius: 5px;
  color: var(--yellow);
  font-weight: bold;
}
</style>