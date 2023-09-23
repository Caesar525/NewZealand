<template>
    <div>
        <Card dis-hover>
            <div class="page-body">
                <Form ref="queryForm" :label-width="100" label-position="left" inline>
                    <Row :gutter="16">
                        <Col span="8">
                            <FormItem :label="L('Keyword')+':'" style="width:100%">
                                <Input v-model="pagerequest.keyword" :placeholder="L('TenancyName')+'/'+L('Name')"></Input>
                            </FormItem>
                        </Col>                 
                    </Row>
                    <Row>
                        <Button @click="create" icon="android-add" type="primary" size="large">{{L('Add')}}</Button>
                        <Button icon="ios-search" type="primary" size="large" @click="getpage" class="toolbar-btn">{{L('Find')}}</Button>
                    </Row>
                </Form>
                <div class="margin-top-10">
                    <Table :loading="loading" :columns="columns" :no-data-text="L('NoDatas')" border :data="list">
                    </Table>
                    <Page  show-sizer class-name="fengpage" :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage"></Page>
                </div>
            </div>
        </Card>
        <create-consume v-model="createModalShow" @save-success="getpage" ></create-consume>
        <edit-consume v-model="editModalShow" @save-success="getpage"></edit-consume>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '@/lib/util'
    import AbpBase from '@/lib/abpbase'
    import PageRequest from '@/store/entities/page-request'
    import CreateBudget from './create-budget.vue'
    import EditBudget from './edit-budget.vue'
    
    export class PageBudgetRequest extends PageRequest{
        keyword:string='';
        isActive:boolean=null;
    }
    
    @Component({
        components:{CreateBudget,EditBudget}
    })
    export default class Budget extends AbpBase{
        edit(){
            this.editModalShow=true;
        }
       
        pagerequest: PageBudgetRequest = new PageBudgetRequest();

        createModalShow:boolean=false;
        editModalShow:boolean=false;
        get list(){
            //return this.$store.state.consume.list;
            return this.$store.state.consume.list;
        };
        get loading(){
            return this.$store.state.consume.loading;
        }
        create(){
            this.createModalShow=true;
        }
        isActiveChange(val:string){
            if(val==='Actived'){
                this.pagerequest.isActive=true;
            }else if(val==='NoActive'){
                this.pagerequest.isActive=false;
            }else{
                this.pagerequest.isActive=null;
            }
        }
        pageChange(page:number){
            this.$store.commit('budget/setCurrentPage',page);
            this.getpage();
        }
        pagesizeChange(pagesize:number){
            this.$store.commit('budget/setPageSize',pagesize);
            this.getpage();
        }
        async getpage(){
            
            this.pagerequest.maxResultCount = this.pageSize;
            this.pagerequest.skipCount = (this.currentPage - 1) * this.pageSize;
            
            await this.$store.dispatch({
                type:'budget/getAll',
                data:this.pagerequest
            })
        }
        get pageSize(){
            return this.$store.state.budget.pageSize;
        }
        get totalCount(){
            return this.$store.state.budget.totalCount;
        }
        get currentPage(){
            return this.$store.state.budget.currentPage;
        }
        columns = [{
            title: this.L('consumemonth'),
            key: 'consumemonth'
        }, {
            title: this.L('extremum'),
            key: 'extremum'
        }, {
            title: this.L('increment'),
            key: 'increment'
        }, {
            title: this.L('lowest'),
            key: 'lowest'
        }, {
            title: this.L('disposableincome'),
            key: 'disposableincome'
        }, {
            title: this.L('totalconsume'),
            key: 'totalconsume'
        }, {
            title: this.L('disposablebalance'),
            key: 'disposablebalance'
        }, {
            title: this.L('Actions'),
            key: 'Actions',
            width: 150,
            render: (h: any, params: any) => {
                return h('div', [
                    h('Button', {
                        props: {
                            type: 'primary',
                            size: 'small'
                        },
                        style: {
                            marginRight: '5px'
                        },
                        on: {
                            click: () => {
                                this.$store.commit('consume/edit', params.row);
                                this.edit();
                            }
                        }
                    }, this.L('Edit')),
                    h('Button', {
                        props: {
                            type: 'error',
                            size: 'small'
                        },
                        on: {
                            click: async () => {
                                this.$Modal.confirm({
                                    title: this.L('Tips'),
                                    content: this.L('DeleteConsumeConfirm'),
                                    okText: this.L('Yes'),
                                    cancelText: this.L('No'),
                                    onOk: async () => {
                                        await this.$store.dispatch({
                                            type: 'consume/delete',
                                            data: params.row
                                        })
                                        await this.getpage();
                                    }
                                })
                            }
                        }
                    }, this.L('Delete'))
                ])
            }
        }]
        async created(){
            this.getpage();
        }
    }
</script>