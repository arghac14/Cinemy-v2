import axiosInstance from './index.js';

class producerAPIService {
    getAll = async() => {
        return await axiosInstance.get("producers")
            .catch(e => {
                console.log(e);
            });
    }
    getById = async(id) => {
        return await axiosInstance.get(`producers/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(producer) => {
        return await axiosInstance.post("producers/", producer)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new producerAPIService();