import axios from 'axios';

class genreService {
    getAll = async() => {
        return await axios.get("https://localhost:44303/api/genres")
            .catch(e => {
                console.log(e);
            });
    }
    getById = async(id) => {
        return await axios.get(`https://localhost:44303/api/genres/${id}`)
            .catch(e => {
                console.log(e);
            });
    }
    add = async(genre) => {
        return await axios.post("https://localhost:44303/api/actors/", genre)
            .catch(e => {
                console.log(e);
            });
    }
}

export default new genreService();