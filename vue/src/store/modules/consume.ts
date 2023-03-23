import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import Consume from '../entities/Consume'

interface ConsumeState extends ListState<Consume> {
    editConsume: Consume;
    //permissions: Array<string>
}
class ConsumeModule extends ListModule<ConsumeState, any, Consume>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<Consume>(),
        loading: false,
        editConsume: new Consume(),
        //permissions: new Array<string>()
    }
    actions = {
        async getAll(context: ActionContext<ConsumeState, any>, payload: any) {
            context.state.loading = true;
            let reponse = await Ajax.get('/api/services/app/ConsumeStatistic/GetAll', { params: payload.data });
            context.state.loading = false;
            let page = reponse.data.result as PageResult<Consume>;
            context.state.totalCount = page.totalCount;
            context.state.list = page.items;
        },
        async create(context: ActionContext<ConsumeState, any>, payload: any) {
            await Ajax.post('/api/services/app/ConsumeStatistic/CreateOrEdit', payload.data);
        },
        async update(context: ActionContext<ConsumeState, any>, payload: any) {
            await Ajax.put('/api/services/app/ConsumeStatistic/CreateOrEdit', payload.data);
        },
        async delete(context: ActionContext<ConsumeState, any>, payload: any) {
            await Ajax.delete('/api/services/app/ConsumeStatistic/Delete?Id=' + payload.data.id);
        },
        async get(context: ActionContext<ConsumeState, any>, payload: any) {
            let reponse = await Ajax.get('/api/services/app/ConsumeStatistic/Get?Id=' + payload.id);
            return reponse.data.result as Consume;
        },
        //async getAllPermissions(context: ActionContext<ConsumeState, any>) {
        //    let reponse = await Ajax.get('/api/services/app/ConsumeStatistic/getAllPermissions');
        //    context.state.permissions = reponse.data.result.items;
        //}
    };
    mutations = {
        setCurrentPage(state: ConsumeState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: ConsumeState, pagesize: number) {
            state.pageSize = pagesize;
        },
        edit(state: ConsumeState, consume: Consume) {
            state.editConsume = consume;
        }
    }
}
const consumeModule = new ConsumeModule();
export default consumeModule;