<template>
    <div>
        <Modal :title="L('EditConsumeList')"
               :value="value"
               @on-ok="save"
               @on-visible-change="visibleChange">
    </div>
</template>