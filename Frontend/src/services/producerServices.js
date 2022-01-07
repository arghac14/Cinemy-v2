import axios from 'axios';

class producerService {
    getAll = async() => {
        return await axios.get("https://localhost:44303/api/producers")
            .catch(e => {
                console.log(e);
            });
    }
    getById = async(id) => {
        return await axios.get(`https://localhost:44303/api/producers/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(producer) => {
        return await axios.post("https://localhost:44303/api/producers/", producer)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new producerService();