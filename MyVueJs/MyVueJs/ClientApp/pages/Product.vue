<template>
    <div class="page">
        <product-details :product="product" />
    </div>
</template>

<script>
import ProductDetails from "../components/product/Details.vue";

export default {
    name: "product",
    components: {
        ProductDetails
    },
    data() {
        return {
            product: null
        }
    },
    methods: {
        setData(product) {
            this.product = product;
        }
    },
    beforeRouteEnter(to, from, next) {
        fetch(`/api/products/${to.params.slug}`)
            .then(response => {
                var data = response.json();
                return data;
            })
            .then(product => {
                next(vm => vm.setData(product));
            });
    }
}
</script>

<style>
    .product {
        font-size: 16px;
        font-weight: bold;
        color: teal;
    }
</style>