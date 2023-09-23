import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import Budget from '../entities/Budget'

interface BudgetState extends ListState<Budget> {
    editConsume: Budget;
    //permissions: Array<string>
}
class BudgetModule extends ListModule<BudgetState, any, Budget>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<Budget>(),
        loading: false,
        editBudget: new Budget(),
        //permissions: new Array<string>()
    }
    actions = {
        async getAll(context: ActionContext<BudgetState, any>, payload: any) {
            context.state.loading = true;
            let reponse = await Ajax.get('/api/services/app/Budget/GetAll', { params: payload.data });
            context.state.loading = false;
            let page = reponse.data.result as PageResult<Budget>;
            context.state.totalCount = page.totalCount;
            context.state.list = page.items;
        },
        async create(context: ActionContext<BudgetState, any>, payload: any) {
            await Ajax.post('/api/services/app/Budget/CreateOrEdit', payload.data);
        },
        async update(context: ActionContext<BudgetState, any>, payload: any) {
            await Ajax.post('/api/services/app/Budget/CreateOrEdit', payload.data);
        },
        async delete(context: ActionContext<BudgetState, any>, payload: any) {
            await Ajax.delete('/api/services/app/Budget/Delete?Id=' + payload.data.id);
        },
        async get(context: ActionContext<BudgetState, any>, payload: any) {
            let reponse = await Ajax.get('/api/services/app/Budget/Get?Id=' + payload.id);
            return reponse.data.result as Budget;
        },
        //async getAllPermissions(context: ActionContext<ConsumeState, any>) {
        //    let reponse = await Ajax.get('/api/services/app/ConsumeStatistic/getAllPermissions');
        //    context.state.permissions = reponse.data.result.items;
        //}
    };
    mutations = {
        setCurrentPage(state: BudgetState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: BudgetState, pagesize: number) {
            state.pageSize = pagesize;
        },
        edit(state: BudgetState, consume: Budget) {
            state.editConsume = consume;
        }
    }
}
const budgetModule = new BudgetModule();
export default budgetModule;