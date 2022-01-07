<template>
    <div class="actor-detail-card">
        <Card id="actor-card" :bordered="false">
        <p id="actor-title"> {{actor.name}} 
        </p> <hr><br> 
        <p class="actor-details">Gender: <span class="actor-data">{{actor.gender}}</span></p>
        <p class="actor-details">DOB: <span class="actor-data">{{actor.dob.slice(0,10)}}</span></p>
        <p class="actor-details">Bio: <span class="actor-data">{{actor.bio}}</span></p>
        <br>
         </Card>   
    </div>
</template>
<script>
export default {
    props: {
        actor: {
            type: Object
        }
    },
}
</script>
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
.actor-details{
  font-size: 20px;
  font-weight: bold;
  color: var(--yellow);
}
.actor-data{
  font-size: 18px;
  font-weight: lighter;
  color: whitesmoke;
  text-align: justify;
}
</style>
