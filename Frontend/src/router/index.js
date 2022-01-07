import Vue from "vue";
import VueRouter from "vue-router";
import SignUp from "../components/SignUp";
import Login from "../components/Login";
import Movie from "../views/Movie.vue";
import Actor from "../views/Actor.vue";
import Producer from "../views/Producer.vue";
import MovieForm from "../views/addMovie.vue";

Vue.use(VueRouter);

const routes = [{
        path: "/",
        name: "Movie",
        component: Movie,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: "/actors",
        name: "Actor",
        component: Actor,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: "/producers",
        name: "Producer",
        component: Producer,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: "/Movie/add",
        name: "MovieForm",
        component: MovieForm,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: "/Movie/:id/edit",
        name: "EditMovieForm",
        component: MovieForm,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: "/signup",
        name: "Signup",
        component: SignUp
    },
    {
        path: "/login",
        name: "Login",
        component: Login
    },
    {
        path :'*',
        redirect: '/'
    }
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
      if (localStorage.getItem('accessToken') == null) {
        next({
          path: '/login',
          params: { nextUrl: to.fullPath }
        })
      } else {
        next();
      }
    } else if (to.matched.some(record => record.meta.guest)) {
      if (localStorage.getItem('accessToken') == null) {
        next()
      } else {
        next()
      }
    } else {
      next()
    }
  })

export default router;