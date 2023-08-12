import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ConsumeList from '../entities/ConsumeList';

interface ConsumeListState extends ListState<ConsumeList> {
    editConsumeList: ConsumeList;
    //permissions: Array<string>
}
class ConsumeListModule extends ListModule<ConsumeListState, any, ConsumeList>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<ConsumeList>(),
        loading: false,
        editConsumeList: new ConsumeList(),
        //permissions: new Array<string>()
    }
    actions = {
        async getAll(context: ActionContext<ConsumeListState, any>, payload: any) {
            context.state.loading = true;
            let reponse = await Ajax.get('/api/services/app/ConsumeList/GetAll', { params: payload.data });
            context.state.loading = false;
            let page = reponse.data.result as PageResult<ConsumeList>;
            context.state.totalCount = page.totalCount;
            context.state.list = page.items;
        },
        async create(context: ActionContext<ConsumeListState, any>, payload: any) {
            await Ajax.post('/api/services/app/ConsumeList/CreateOrEdit', payload.data);
        },
        async update(context: ActionContext<ConsumeListState, any>, payload: any) {
            await Ajax.post('/api/services/app/ConsumeList/CreateOrEdit', payload.data);
        },
        async delete(context: ActionContext<ConsumeListState, any>, payload: any) {
            await Ajax.delete('/api/services/app/ConsumeList/Delete?Id=' + payload.data.id);
        },
        async get(context: ActionContext<ConsumeListState, any>, payload: any) {
            let reponse = await Ajax.get('/api/services/app/ConsumeList/Get?Id=' + payload.id);
            return reponse.data.result as ConsumeList;
        },
        async export(context: ActionContext<ConsumeListState, any>, payload: any) {

        }
        //async getAllPermissions(context: ActionContext<ConsumeState, any>) {
        //    let reponse = await Ajax.get('/api/services/app/ConsumeStatistic/getAllPermissions');
        //    context.state.permissions = reponse.data.result.items;
        //}
    };
    mutations = {
        setCurrentPage(state: ConsumeListState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: ConsumeListState, pagesize: number) {
            state.pageSize = pagesize;
        },
        edit(state: ConsumeListState, consumelist: ConsumeList) {
            state.editConsumeList = consumelist;
        }
    }
}
const consumeListModule = new ConsumeListModule();
export default consumeListModule;