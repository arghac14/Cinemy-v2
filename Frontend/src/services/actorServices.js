import axios from 'axios';

class actorService {
    getAll = async() => {
        return await axios.get("https://localhost:44303/api/actors")
            .catch(e => {
                console.log(e);
            });
    }
    getById = async(id) => {
        return await axios.get(`https://localhost:44303/api/actors/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(actor) => {
        return await axios.post("https://localhost:44303/api/actors/", actor)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new actorService();