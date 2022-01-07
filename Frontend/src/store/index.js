import Vue from "vue";
import Vuex from "vuex";
import movieAPIService from "../services/movieAPIService";
import actorAPIService from "../services/actorAPIService";
import producerAPIService from "../services/producerAPIService";
import genreAPIService from "../services/genreAPIService";

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        isAdminUser: 1,
        userName: '',
        movies: [],
        actors: [],
        producers: [],
        genres: []
    },
    actions: {
        getAllMovies({ state }) {
            movieAPIService.getAll().then((res) => {
                state.movies = res.data;
            });
        },
        getAllActors({ state }) {
            actorAPIService.getAll().then((res) => {
                state.actors = res.data;
            });
        },
        getAllProducers({ state }) {
            producerAPIService.getAll().then((res) => {
                state.producers = res.data;
            });
        },
        getAllGenres({ state }) {
            genreAPIService.getAll().then((res) => {
                state.genres = res.data;
            });
        },

    }
});