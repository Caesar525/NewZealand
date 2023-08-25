<template>
    <div>
        <Card dis-hover>
            <div class="page-body">
                <Form ref="queryForm" :label-width="100" label-position="left" inline>
                    <Row :gutter="16">
                        <Col span="8">
                        <!--导入功能-->
                        <FormItem :label="L('Keyword')+':'" style="width:100%">
                            <Input v-model="pagerequest.keyword" :placeholder="L('TenancyName')+'/'+L('Name')"></Input>
                        </FormItem>
                        </Col>
                    </Row>
                    <Row>
                        <Button @click="create" icon="android-add" type="primary" size="large">{{L('Add')}}</Button>
                        <Button icon="ios-search" type="primary" size="large" @click="getpage" class="toolbar-btn">{{L('Find')}}</Button>
                        <Button icon="" type="primary" size="large" @click="handleExport" class="toolbar-btn">{{L('Import')}}</Button>
                        <!--<el-button class="filter-item" size="mini" type="success" icon="el-icon-download" @click="handleExport()">导入</el-button>-->
                    </Row>
                </Form>
                <div class="margin-top-10">
                    <Table :loading="loading" :columns="columns" :no-data-text="L('NoDatas')" border :data="list">
                    </Table>
                    <Page show-sizer class-name="fengpage" :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage"></Page>
                </div>
            </div>
        </Card>
        <CreateConsumeList v-model="createModalShow" @save-success="getpage"></CreateConsumeList>
        <EditConsumeList v-model="editModalShow" @save-success="getpage"></EditConsumeList>
        <UploadConsumeList v-model="uploadModalShow" @save-success="getpage"></UploadConsumeList>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '@/lib/util'
    import AbpBase from '@/lib/abpbase'
    import PageRequest from '@/store/entities/page-request'
    import CreateConsumeList from './create-consumelist.vue'
    import EditConsumeList from './edit-consumelist.vue'
    import UploadConsumeList from './upload-consumelist.vue'

    class PageConsumelistRequest extends PageRequest{
        keyword:string='';
        isActive:boolean=null;
    }
    @Component({
        components: { CreateConsumeList,EditConsumeList,UploadConsumeList }
    })
    export default class ConsumeList extends AbpBase{
        edit(){
            this.editModalShow=true;
        }

        pagerequest: PageConsumelistRequest = new PageConsumelistRequest();

        createModalShow:boolean=false;
        editModalShow:boolean=false;
        uploadModalShow:boolean=false;
        get list(){
            //return this.$store.state.consume.list;
            return this.$store.state.consumelist.list;
        };
        get loading(){
            return this.$store.state.consumelist.loading;
        }
        create(){
            this.createModalShow=true;
        }
        handleExport(){
            this.uploadModalShow=true;
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
            this.$store.commit('consumelist/setCurrentPage',page);
            this.getpage();
        }
        pagesizeChange(pagesize:number){
            this.$store.commit('consumelist/setPageSize',pagesize);
            this.getpage();
        }
        async getpage(){

            this.pagerequest.maxResultCount = this.pageSize;
            this.pagerequest.skipCount = (this.currentPage - 1) * this.pageSize;

            await this.$store.dispatch({
                type:'consumelist/getAll',
                data:this.pagerequest
            })
        }
        get pageSize() {
            return this.$store.state.consumelist.pageSize;
        }
        get totalCount() {
            return this.$store.state.consumelist.totalCount;
        }
        get currentPage() {
            return this.$store.state.consumelist.currentPage;
        }
        columns = [{
            title: this.L('consumemonth'),
            key: 'consumemonth'
        }, {
            title: this.L('consume'),
            key: 'consume'
        }, {
            title: this.L('usage'),
            key: 'usage'
        }, {
            title: this.L('remark'),
            key: 'remark'
        }, {
            title: this.L('location'),
            key: 'location'
        }, {
            title: this.L('happentime'),
            key: 'happentime'
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
                                this.$store.commit('consumelist/edit', params.row);
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
                                    content: this.L('DeleteConsumeListConfirm'),
                                    okText: this.L('Yes'),
                                    cancelText: this.L('No'),
                                    onOk: async () => {
                                        await this.$store.dispatch({
                                            type: 'consumelist/delete',
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