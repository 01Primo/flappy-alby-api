import {HttpClient} from "./httpClient.js";

export class RankingClient {
    #httpClient;

    constructor(url) {
        this.#httpClient = new HttpClient(url);
    }

    get() {
        return this.#httpClient.get();
    }

    send(name, total) {
        return this.#httpClient.post({Name: name, Total: total});
    }
}