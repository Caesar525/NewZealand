<template>
    <div>
        <Modal :title="L('EditConsumeList')"
               :value="value"
               @on-ok="save"
               @on-visible-change="visibleChange">
            <form ref="consumelistForm" label-position="top" :rules="consumelistRule" :model="consumelist">
                <Tabs value="detial">
                  <TabPane :label="L('ConsumeDetails')" name="detail"></TabPane>
                </Tabs>
            </form>
        </Modal>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '../../../lib/util'
    import AbpBase from '../../../lib/abpbase'
    import ConsumeList from '@/store/entities/ConsumeList';
    @Component
    export default class UploadConsumeList extends AbpBase{
        @Prop({type:Boolean,default:false}) value:boolean;
        consumelist: ConsumeList = new ConsumeList();
        get permissions(){
            return this.$store.state.role.permissions
        }
        save(){
            (this.$refs.consumelistForm as any).validate(async (valid:boolean)=>{
                if (valid) {
                    this.consumelist.consumemonth = new Date(this.consumelist.consumemonth.setDate(this.consumelist.consumemonth.getDate() + 1));
                    this.consumelist.happentime = new Date(this.consumelist.happentime.setDate(this.consumelist.happentime.getDate() + 1));
                    await this.$store.dispatch({
                        type:'consumelist/update',
                        data: this.consumelist
                    });
                    (this.$refs.consumelistForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input',false);
                }
            })
        }
        cancel(){
            (this.$refs.consumelistForm as any).resetFields();
            this.$emit('input',false);
        }
        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }else{
                this.consumelist = Util.extend(true, {}, this.$store.state.consumelist.editConsumeList);
            }
        }
        consumelistRule = {
            consumemonth: [],
            consume: [],
            usage: [],
            remark: [],
            location: [],
            happentime: []
        }
    }
</script>