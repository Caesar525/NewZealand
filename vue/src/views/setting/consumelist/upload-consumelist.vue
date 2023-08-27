<template>
    <div>
        <Modal :title="L('EditConsumeList')" :value="value" @on-visible-change="visibleChange">
            <Tabs value="detial">
                <TabPane :label="L('ConsumeDetails')" name="detail">
                  <!-- 上传控件 -->
                  <div>
                      <Upload
                        :action="uploadURL"
                        :on-success="onSuccess"
                        accept=".xls, .xlsx"
                        :show-upload-list="true"
                      >
                        <Button icon="android-add" type="primary">{{btnTitle}}</Button>
                      </Upload>
                  </div>
                  <!-- 上传控件 -->
                </TabPane>
              </Tabs>
              <div slot="footer">
                <Button @click="cancel">{{L('Cancel')}}</Button>
                <Button @click="save" type="primary">{{L('OK')}}</Button>
            </div>
        </Modal>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '../../../lib/util';
    import AbpBase from '../../../lib/abpbase';
    import ConsumeList from '@/store/entities/ConsumeList';
    import appconst from "../../../lib/appconst";

    @Component
    export default class UploadConsumeList extends AbpBase{
        uploadURL =
        appconst.remoteServiceBaseUrl + "/api/services/app/UploadExcelFile/UploadFile";
        async onSuccess(response, file, fileList) {
            //上传完成触发事件uploadCompleted
            this.$emit("uploadCompleted", response.result);
        }
        /**按钮显示内容 */
        @Prop({ type: String, default: "导入" }) btnTitle: String;
        @Prop({type:Boolean,default:false}) value:boolean;

        visibleChange(value:boolean){
            if(!value){
                this.$emit('input',value);
            }
        }

        // @Prop({type:Boolean,default:false}) value:boolean;
        // consumelist: ConsumeList = new ConsumeList();
        // get permissions(){
        //     return this.$store.state.role.permissions
        // }
        save(){
            console.log("asdasjodasuihfas");
            // (this.$refs.consumelistForm as any).validate(async (valid:boolean)=>{
                
            //     if (valid) {
            //         alert("1113123");
            //     }
            // })

            alert("111312311111111111111111111111111");
            this.$emit('save-success');
            this.$emit('input',false);
        }
        cancel(){
            alert("111312311111111111111111111111111");
            // (this.$refs.consumelistForm as any).resetFields();
            this.$emit('input',false);
        }
        // visibleChange(value:boolean){
        //     if(!value){
        //         this.$emit('input',value);
        //     }else{
        //         this.consumelist = Util.extend(true, {}, this.$store.state.consumelist.editConsumeList);
        //     }
        // }
        // consumelistRule = {
        //     consumemonth: [],
        //     consume: [],
        //     usage: [],
        //     remark: [],
        //     location: [],
        //     happentime: []
        // }
    }
</script>