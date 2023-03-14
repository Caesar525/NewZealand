<template>
    <div>
        <Modal
         :title="L('CreateNewConsume')"
         :value="value"
         @on-ok="save"
         @on-visible-change="visibleChange"
        >
            <Form ref="consumeForm"  label-position="top" :rules="consumeRule" :model="consume">
                <Tabs value="detail">
                    <TabPane :label="L('ConsumeDetails')" name="detail">
                        <!--<FormItem :label="L('RoleName')" prop="name">
        <Input v-model="role.name" :maxlength="32" :minlength="2"></Input>
    </FormItem>
    <FormItem :label="L('DisplayName')" prop="displayName">
        <Input v-model="role.displayName" :maxlength="32" :minlength="2"></Input>
    </FormItem>
    <FormItem :label="L('Description')" prop="description">
        <Input v-model="role.description" :maxlength="1024"></Input>
    </FormItem>-->
                        <FormItem :label="L('consumemonth')" prop="consumemonth">
                            <DatePicker v-model="consume.consumemonth" type="date" format="yyyy-MM-dd" :placeholder="L('SelectDate')" :minlength="2"></DatePicker>
                        </FormItem>
                        <FormItem :label="L('extremum')" prop="extremum">
                            <Input v-model="consume.extremum" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('increment')" prop="increment">
                            <Input v-model="consume.increment" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('lowest')" prop="lowest">
                            <Input v-model="consume.lowest" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('disposableincome')" prop="disposableincome">
                            <Input v-model="consume.disposableincome" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('totalconsume')" prop="totalconsume">
                            <Input v-model="consume.totalconsume" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('disposablebalance')" prop="disposablebalance">
                            <Input v-model="consume.disposablebalance" :maxlength="32" :minlength="2"></Input>
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
    import Consume from '@/store/entities/Consume';
    @Component
    export default class CreateConsume extends AbpBase{
        @Prop({type:Boolean,default:false}) value:boolean;
        consume: Consume = new Consume();
        get permissions(){
            return this.$store.state.role.permissions
        }
        save(){
            (this.$refs.consumeForm as any).validate(async (valid:boolean)=>{
                if(valid){
                    //if (!this.consume.grantedPermissions){
                    //    this.consume.grantedPermissions=[];
                    //}
                    await this.$store.dispatch({
                        type:'consume/create',
                        data: this.consume
                    });
                    (this.$refs.consumeForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input',false);
                }
            })
        }
        cancel(){
            (this.$refs.consumeForm as any).resetFields();
            this.$emit('input', false);
        }
        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }
        }
        consumeRule ={
            //name:[{required: true,message:this.L('FieldIsRequired',undefined,this.L('RoleName')),trigger: 'blur'}],
            //displayName:[{required:true,message:this.L('FieldIsRequired',undefined,this.L('DisplayName')),trigger: 'blur'}]

            consumemonth: [],
            extremum: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('extremum')), trigger: 'blur' }],
            increment: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('increment')), trigger: 'blur' }],
            lowest: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('lowest')), trigger: 'blur' }],
            disposableincome: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('disposableincome')), trigger: 'blur' }],
            totalconsume: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('month')), trigger: 'blur' }],
            disposablebalance: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('disposablebalance')), trigger: 'blur' }]
        }
    }
</script>

