<template>
    <div class="page">
        <product-list :products="products" />
    </div>
</template>

<script>
    import ProductList from "../components/catalogue/ProductList.vue";

export default {
    name: "catalogue",
    components: {
        ProductList
    },
    data() {
        return {
            products: []
        };
    },
    methods: {
        setData(products) {
            this.products = products;
        }
    },
    beforeRouteEnter(to, from, next) {
        console.log("Hey! Im getting data");
        fetch("/api/products")
            .then(response => {
                var data = response.json();
                console.dir(data);
                return data;
            })
            .then(products => {
                next(vm => vm.setData(products));
            });
        }
};
</script>
