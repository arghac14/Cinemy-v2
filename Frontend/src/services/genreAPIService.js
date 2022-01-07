import axiosInstance from './index.js';

class genreService {
    getAll = async() => {
        return await axiosInstance.get("genres")
            .catch(e => {
                console.log(e);
            });
    }
    getById = async(id) => {
        return await axiosInstance.get(`genres/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(genre) => {
        return await axiosInstance.post("actors/", genre)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new genreService();