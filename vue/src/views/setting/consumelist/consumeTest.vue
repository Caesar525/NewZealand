<template>
    <div>
        <Modal :title="L('CreateNewConsume')"
               :value="value"
               @on-visible-change="visibleChange">
            
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
        cancel(){
            (this.$refs.consumelistForm as any).resetFields();
            this.$emit('input', false);
        }
        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }
        }
        consumelistRule ={
            consumemonth: [],
            consume: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('extremum')), trigger: 'blur' }],
            usage: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('increment')), trigger: 'blur' }],
            remark: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('lowest')), trigger: 'blur' }],
            location: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('disposableincome')), trigger: 'blur' }],
            happentime: []
        }
    }
</script>

