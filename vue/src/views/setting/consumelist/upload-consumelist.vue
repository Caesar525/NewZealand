<template>
    <div>
        <Modal :title="L('EditConsumeList')" >
            <Tabs value="detial">
                <TabPane :label="L('ConsumeDetails')" name="detail">
                  <!-- 上传控件 -->
                  <div>
                      <Upload
                        :action="uploadURL"
                        :on-success="onSuccess"
                        accept=".xls, .xlsx"
                        :show-upload-list="false"
                      >
                        <Button icon="android-add" type="primary">{{btnTitle}}</Button>
                      </Upload>
                  </div>
                  <!-- 上传控件 -->
                </TabPane>
              </Tabs>
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
        appconst.remoteServiceBaseUrl + "/api/services/app/Excel/UploadExcelFile";
        async onSuccess(response, file, fileList) {
            //上传完成触发事件uploadCompleted
            this.$emit("uploadCompleted", response.result);
        }
        /**按钮显示内容 */
        @Prop({ type: String, default: "导入" }) btnTitle: String;

        // @Prop({type:Boolean,default:false}) value:boolean;
        // consumelist: ConsumeList = new ConsumeList();
        // get permissions(){
        //     return this.$store.state.role.permissions
        // }
        // save(){
        //     (this.$refs.consumelistForm as any).validate(async (valid:boolean)=>{
        //         if (valid) {
        //             this.consumelist.consumemonth = new Date(this.consumelist.consumemonth.setDate(this.consumelist.consumemonth.getDate() + 1));
        //             this.consumelist.happentime = new Date(this.consumelist.happentime.setDate(this.consumelist.happentime.getDate() + 1));
        //             await this.$store.dispatch({
        //                 type:'consumelist/update',
        //                 data: this.consumelist
        //             });
        //             (this.$refs.consumelistForm as any).resetFields();
        //             this.$emit('save-success');
        //             this.$emit('input',false);
        //         }
        //     })
        // }
        // cancel(){
        //     (this.$refs.consumelistForm as any).resetFields();
        //     this.$emit('input',false);
        // }
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