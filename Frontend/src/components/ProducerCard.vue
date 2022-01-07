<template>
    <div class="producer-detail-card">
        <Card id="producer-card" :bordered="false">
        <p id="producer-title"> {{producer.name}} 
        </p> <hr><br> 
        <p class="producer-details">Gender: <span class="producer-data">{{producer.gender}}</span></p>
        <p class="producer-details">DOB: <span class="producer-data">{{producer.dob.slice(0,10)}}</span></p>
        <p class="producer-details">Bio: <span class="producer-data">{{producer.bio}}</span></p>
        <br>
         </Card>   
    </div>
</template>
<script>
export default {
    props: {
        producer: {
            type: Object
        }
    },
}
</script>
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
.producer-details{
  font-size: 20px;
  font-weight: bold;
  color: var(--yellow);
}
.producer-data{
  font-size: 18px;
  font-weight: lighter;
  color: whitesmoke;
  text-align: justify;
}
</style>
