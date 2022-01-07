<template>
  <div class="movieform">    
  <Row :gutter="10" justify="center">
    <Col span="24">
    <div id="form" style="text-align: center">
      <Form :model="formItem" ref="formItem" :rules="ruleValidate"  :label-width="90">
        <FormItem required label="Title: " id="form-label" prop="movieTitle">
            <Input v-model="formItem.movieTitle" id="form-input" placeholder="Enter Movie Title...."></Input>
        </FormItem>
        <FormItem label="Poster: " prop="poster">
          <input v-on:change="handleUpload" id="poster" type="file">
        </FormItem>
        <Row>
          <Col :xs="18" :sm="20" :md="20" :lg="20">
             <FormItem required label="Actors:" prop="actors"> 
                <Select id="form-input" v-model="formItem.actors" multiple placeholder="Select Actors" filterable>
                  <Option  v-for="actor in actorDropdownOptions" :value="actor.id" :key="actor.id">{{actor.name}}</Option>
                </Select>
              </FormItem>
          </Col>
          <Col :xs="6" :sm="4" :md="4" :lg="4" style="text-align: center">
          <Button id="sm-button" :size="small" type="primary" @click="actorModal=true">
            Add 
            <lord-icon id="icon"
                src="https://cdn.lordicon.com//mecwbjnp.json"
                trigger="loop"
                colors="primary:#000000,secondary:#000000">
            </lord-icon>
          </Button>
          </Col>
         <Col :xs="18" :sm="20" :md="20" :lg="20">
              <FormItem required label="Director:" prop="producer">        
                <Select id="form-input" v-model="formItem.producer" placeholder="Select Director" filterable>
                    <Option  v-for="producer in producerDropdownOptions" :value="producer.id" :key="producer.id">{{producer.name}}</Option>
                </Select>
              </FormItem>    
          </Col> 
          <Col :xs="6" :sm="4" :md="4" :lg="4" style="text-align: center">
          <Button id="sm-button" :size="small" type="primary" @click="producerModal=true">
            Add 
            <lord-icon id="icon"
                src="https://cdn.lordicon.com//mecwbjnp.json"
                trigger="loop"
                colors="primary:#000000,secondary:#000000">
            </lord-icon>
          </Button>
          </Col>               
        </Row>
    
          <Row>
          <Col span="12">
             <FormItem required label="Genres:" prop="genres">
                <Select id="form-input" multiple v-model="formItem.genres" placeholder="Select Genres" filterable>
                  <Option  v-for="genre in genreDropdownOptions" :value="genre.id" :key="genre.id">{{genre.name}}</Option>
                </Select>
              </FormItem>
          </Col>
          <Col span="2" ></Col>
          <Col span="10">
              <FormItem required label="Year:" prop="year">        
                <Select id="form-input" v-model="formItem.year" placeholder="Select Release Year" filterable>
                    <Option v-for="year in yearDropdownOptions()" :value="year" :key="year">{{year}}</Option>
                </Select>
              </FormItem>    
          </Col>        
        </Row>
         <FormItem required label="Plot:" prop="plot">
            <Input id="form-input" v-model="formItem.plot" type="textarea" :autosize="{minRows: 3,maxRows: 4}" placeholder="Enter Movie Plot...."></Input>
          </FormItem>
         <FormItem>
            <Button @click="movieFormSubmit('formItem')" id="button" :size="large" type="primary" long>Submit</Button>
          </FormItem>
    </Form>
    </div>
    </Col>
    </Row>
    
     <div class="modal">
      <Modal v-model="actorModal" width="720">
        <p slot="header" id="actor-modal">
            <span>Add Actor</span>
        </p>
        <ActorForm @modalHasClosed="actorModal = $event"/>
        <div slot="footer">
         </div>  
      </Modal>
       <Modal v-model="producerModal" width="720">
        <p slot="header" id="actor-modal">
            <span>Add Director</span>
        </p>
        <ProducerForm @modalHasClosed="producerModal = $event"/>
        <div slot="footer">
         </div>  
      </Modal>
    </div>
 </div>
</template>

<script>
import ActorForm from "../components/ActorForm.vue"
import ProducerForm from "../components/ProducerForm.vue"
import { mapState } from "vuex";
import movieAPIService from "../services/movieAPIService";
import firebase from 'firebase';

    export default {
        data () {
            return {
                actorModal: false,
                producerModal: false,
                movieId: null,
                formItem: {
                    movieTitle: '',
                    poster: "",
                    actors: [],
                    producer: '',
                    genres: [],
                    year: '',
                    plot: ""
                },
                props: ["id"],
                ruleValidate: {
                    movieTitle: [
                        { required: true, type: 'string', min: 1, message: 'Movie title cannot be empty!', trigger: 'blur'} 
                    ],
                    plot: [
                        { required: true, message: 'Please enter the movie plot!', trigger: 'blur' }
                    ]
                }
            }            
        },

        beforeCreate() {
          this.$store.dispatch("getAllActors");
          this.$store.dispatch("getAllProducers");
          this.$store.dispatch("getAllGenres");
        },

        methods: {
          yearDropdownOptions(){
              var years = []
              for(var i=2021; i>1900; i--){
                years.push(i);
              }
              return years;
          },
         handleUpload(e){
            var posterImage = e.target.files[0];
            var storage = firebase.storage();
            var storageRef = storage.ref('/posters/' + posterImage.name);
            storageRef.put(posterImage).then(function() {
                storageRef.getDownloadURL().then(function(link) {
                     localStorage.setItem('poster', JSON.stringify(link)); 
                })
            });
         },
         async movieFormSubmit(data){
            this.$refs[data].validate((valid) => {
                    if (valid) {
                        var uploadedPoster = localStorage.getItem('poster');
                        if(uploadedPoster!=null){
                            this.formItem.poster = uploadedPoster.replace(/['"]+/g, '');
                        }   
                        let movieData = {
                          name: this.formItem.movieTitle,
                          yearOfRelease: this.formItem.year,
                          producerId: this.formItem.producer,
                          actor: this.formItem.actors,
                          genre: this.formItem.genres,
                          plot: this.formItem.plot,
                          poster: this.formItem.poster,
                        };
                         if (this.movieId == null) {
                            movieAPIService
                              .add(movieData)
                              .then(() => {
                                this.$Message.success('Success!');
                                localStorage.removeItem("poster");
                                this.$router.push("/");
                                });
                        }
                        else{
                          movieAPIService
                            .update(movieData, this.movieId)
                            .then(() => {
                               this.$Message.success('Success!');
                                localStorage.removeItem("poster");
                                this.$router.push("/");
                            });
                        }
                        
                    } 
                    else {
                        this.$Message.error('Failed!');
                    }
                    
                })
          }
        },
         created() {
            if (this.$route.params.id) {
              this.movieId = this.$route.params.id;
              movieAPIService.getById(this.movieId).then(({ data }) => {
                this.formItem.actors = data.actor.map((a) => a.id);
                this.formItem.plot = data.plot;
                this.formItem.movieTitle = data.name;
                this.formItem.genres = data.genre.map((g) => g.id);
                this.formItem.producer = data.producer.id;
                this.formItem.year = data.yearOfRelease;
                this.formItem.poster = data.poster;
              });    
            }
        },
        computed: {
        ...mapState({
            actorDropdownOptions: (state) => {
                return state.actors;
            },
            producerDropdownOptions: (state) => {
                return state.producers;
            },
            genreDropdownOptions: (state) => {
                return state.genres;
            }
          })
        },
        components:{
          ActorForm,
          ProducerForm
        }
    }
</script>

<style scoped>

#poster{
  color: var(--yellow);
  float: left;
}

::v-deep .ivu-form-item-label{
  color: var(--yellow) !important;
}

::v-deep .ivu-input{
  font-size: 18px !important;
}

::v-deep .ivu-tag{
  background-color: var(--yellow) !important;
  color: black !important;
}

::v-deep .ivu-modal-content{
  background-color: var(--red) !important;
  color: var(--yellow) !important;
}

::v-deep .ivu-modal-header{
  color: var(--yellow) !important;
}

.movieform{
   color: var(--black); 
   font-size:15px; 
   font-weight: bold
}

#form{
  width: 100%;
  height: 100%;
  padding: 1rem;
  padding-left: 1rem;
  padding-right: 2rem;
  background: #980A0A;
  box-shadow: inset 8px 8px 12px #3d0404,
            inset -8px -8px 12px #f31010;
}

#form-input{
  font-size: 15px;
  background: var(--red);
  box-shadow:  4px 4px 7px #3d0404,
             -4px -4px 7px #f31010;
}

#button{
  border-width: 0px;
  color: var(--black);
  font-size: 20px;
  font-weight: bold;
  height: 40px;
  border-radius: 7px;
  background: var(--yellow);
  box-shadow:  5px 5px 11px #3d0404,
             -5px -5px 11px #f31010;             
}
#sm-button{
  border-width: 0px;
  color: var(--black);
  font-weight: bold;
  border-radius: 4px;
  background: var(--yellow);
  box-shadow:  5px 5px 11px #3d0404,
             -5px -5px 11px #f31010;             
}

#actor-modal{
  color: var(--yellow);
  text-align: center;
  font-weight: bold;
  font-size: 30x;
}

#icon{
  width:25px;
  height:25px
}

::v-deep .ivu-icon-ios-close{
  color: yellow !important;
}
</style>