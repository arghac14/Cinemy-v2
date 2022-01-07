<template>
<div>
  <div class="actor-list">
    <div v-if="actors.length==0" id="no-data">No data available!</div>
    <div id="actor-cards-wrapper">
      <Row id="actor-list-row">
        <Col :xs="24" :sm="12" :md="8" :lg="8" id="actor-card-col" v-for="(actor, index) in actors" :key="index">
            <ActorCard :actor="actor"></ActorCard>
        </Col>
        
      </Row>
    </div>
  </div>
</div>
</template>

<script>
import ActorCard from "./ActorCard.vue";
import {mapState, mapActions} from 'vuex';
export default{
  data(){
    return{

    }
  },
  beforeCreate() {
    this.$store.dispatch("getAllActors");
  },
  computed:{
    ...mapState([
      'actors',
    ]),
  },
  methods:{
    ...mapActions(["getAllActors"]),
  },
  components:{
    ActorCard
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#actor-cards-wrapper{
  padding: 10px;
  margin: 10px;
}
#actor-list-row{
  padding: 10px;

}
#actor-card-col{
  padding:10px;
}
#actor-card{
  width: 100%;
  height: 100%;
  background-color: var(--red);
  border-radius: 25px;
  background: var(--red);
  box-shadow:  8px 8px 12px #360303,
             -8px -8px 12px #d60b0b;
}
#actor-title{
  font-size: 20px;
  font-weight: bolder;
  color: var(--yellow);

}
#actor-details{
  font-size: 20px;
  font-weight: bold;
  color: var(--yellow);
}
#actor-data{
  font-size: 18px;
  font-weight: lighter;
  color: whitesmoke;
  text-align: justify;
}
#actor-poster{
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
#no-data {
  color: whitesmoke;
  font-size: 30px;
  text-align: center;
}
</style>
