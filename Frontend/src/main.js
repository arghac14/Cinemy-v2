import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import ViewUI from 'view-design';
import 'view-design/dist/styles/iview.css';
import locale from 'view-design/dist/locale/en-US';
import firebase from 'firebase';

Vue.use(ViewUI, { locale });
Vue.config.productionTip = false;


var firebaseConfig = {
    apiKey: "AIzaSyCtnoS9B04BJN5rEfXcU6W7YI0pSICVYDg",
    authDomain: "imdb-f7bb2.firebaseapp.com",
    databaseURL: "https://imdb-f7bb2-default-rtdb.firebaseio.com",
    projectId: "imdb-f7bb2",
    storageBucket: "imdb-f7bb2.appspot.com",
    messagingSenderId: "395072919338",
    appId: "1:395072919338:web:aaf2b14218219b3a7af053",
    measurementId: "G-ZVEXRY6B99"
};

firebase.initializeApp(firebaseConfig);

new Vue({
    router,
    store,
    render: (h) => h(App),
}).$mount("#app");