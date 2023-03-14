import Entity from './entity'

export default class Consume extends Entity<number>{
    consumemonth:Date;
    extremum: number;
    increment: number;
    lowest: number;
    disposableincome:number;
    totalconsume:number;
    disposablebalance:number;
}