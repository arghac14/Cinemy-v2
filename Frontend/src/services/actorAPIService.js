import axiosInstance from './index.js';

class actorAPIService {
    getAll = async() => {
        return await axiosInstance.get("https://localhost:44303/api/actors")
            .catch(e => {
                console.log(e);
            });
    }
    getById = async(id) => {
        return await axiosInstance .get(`https://localhost:44303/api/actors/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(actor) => {
        return await axiosInstance .post("https://localhost:44303/api/actors/", actor)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new actorAPIService();