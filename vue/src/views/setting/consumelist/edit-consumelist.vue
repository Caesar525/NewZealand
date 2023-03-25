<template>
    <div>
        <Modal :title="L('EditConsumeList')"
               :value="value"
               @on-ok="save"
               @on-visible-change="visibleChange">
            <Form ref="consumelistForm" label-position="top" :rules="consumelistRule" :model="consumelist">
                <Tabs value="detail">
                    <TabPane :label="L('ConsumeDetails')" name="detail">
                        <FormItem :label="L('consumemonth')" prop="consumemonth">
                            <DatePicker v-model="consumelist.consumemonth" type="datetime" value-format="yyyy-MM-dd" format="yyyy-MM-dd" :placeholder="L('SelectDate')" :minlength="2"></DatePicker>
                        </FormItem>
                        <FormItem :label="L('consume')" prop="consume">
                            <Input v-model="consumelist.consume" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('usage')" prop="usage">
                            <Input v-model="consumelist.usage" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('remark')" prop="remark">
                            <Input v-model="consumelist.remark" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('location')" prop="location">
                            <Input v-model="consumelist.location" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('happentime')" prop="happentime">
                            <DatePicker v-model="consumelist.happentime" type="datetime" value-format="yyyy-MM-dd" format="yyyy-MM-dd" :placeholder="L('SelectDate')" :minlength="2"></DatePicker>
                        </FormItem>
                    </TabPane>
                </Tabs>
            </Form>
            <div slot="footer">
                <Button @click="cancel">{{L('Cancel')}}</Button>
                <Button @click="save" type="primary">{{L('OK')}}</Button>
            </div>
        </Modal>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '../../../lib/util'
    import AbpBase from '../../../lib/abpbase'
    import ConsumeList from '@/store/entities/ConsumeList';
    @Component
    export default class CreateConsumeList extends AbpBase{
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

