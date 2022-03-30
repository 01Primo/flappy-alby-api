export class Stopwatch {
    #start = 0;
    #final = 10000;
    #bonus = 0;

    #total = 0;

    get current() {
        return Date.now() - this.#start + this.#bonus;
    }

    get final() {
        return new Date(this.#final - this.#bonus);
    }

    get percentage() {
        return this.current / this.#final * 100;
    }

    get total() {
        return new Date(this.#total);
    }

    get formattedTotal() {
        let t = this.total;
        return `${ (t.getHours()-1).round2() }:${ t.getMinutes().round2() }:${ t.getSeconds().round2() }.${ t.getMilliseconds().round2() }`
    }

    get over() {
        return this.#final - this.current < 0;
    }

    start(final) {
        this.#start = Date.now();
        this.#final = final;
        this.#bonus = 0;
    }

    stop() {
        this.#total += this.#final - this.#bonus;
    }

    applyBonus(value, timestep) {
        this.#bonus += value * timestep;
    }
}
