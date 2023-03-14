import Entity from './entity'

export default class ConsumeList extends Entity<number>{
    consumemonth: Date;
    consume: number;
    usage: string;
    remark: string;
    location: string;
    happentime: Date;
}