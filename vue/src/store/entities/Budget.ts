import Entity from './entity'

export default class Budget extends Entity<number>{
    budgetDate:Date;
    amountOfBudget: number;
    budgetSurplus: number;
    usageRate: number;
    remark:string;
}