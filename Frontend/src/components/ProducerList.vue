<template>
  <div class="producer-list">
    <div id="producer-cards-wrapper">
      <div v-if="producers.length==0" id="no-data">No data available!</div>
      <Row id="producer-list-row">
        <Col :xs="24" :sm="12" :md="8" :lg="8" id="producer-card-col" v-for="(producer, index) in producers" :key="index">
            <ProducerCard :producer="producer"></ProducerCard>
        </Col>
      </Row>
    </div>
  </div>
</template>

<script>
import ProducerCard from "./ProducerCard.vue";
import {mapState, mapActions} from 'vuex';
export default{
  data(){
    return{
    }
  },
  beforeCreate() {
    this.$store.dispatch("getAllProducers");
  },
  computed:{
    ...mapState([
      'producers',
    ]),
  },
  methods:{
    ...mapActions(["getAllProducers"]),
  },
  components:{
    ProducerCard
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#producer-cards-wrapper{
  padding: 10px;
  margin: 10px;
}
#producer-list-row{
  padding: 10px;

}
#producer-card-col{
  padding:10px;
}
#producer-card{
  width: 100%;
  height: 100%;
  background-color: var(--red);
  border-radius: 25px;
  background: var(--red);
  box-shadow:  8px 8px 12px #360303,
             -8px -8px 12px #d60b0b;
}
#producer-title{
  font-size: 20px;
  font-weight: bolder;
  color: var(--yellow);

}
#producer-details{
  font-size: 20px;
  font-weight: bold;
  color: var(--yellow);
}
#producer-data{
  font-size: 18px;
  font-weight: lighter;
  color: whitesmoke;
  text-align: justify;
}
#producer-poster{
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
