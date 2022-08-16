export class SearchParamns {
    month: number;
    year: number;

    constructor() {
        var date = new Date();
        this.month = date.getMonth() + 1;
        this.year = date.getFullYear();
    }
}