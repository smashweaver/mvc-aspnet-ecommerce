function deleteSku(sku) {
    cartDeleteForm.elements["sku"].value = sku;
    flex.submitForm(cartDeleteForm, "/cart");
}       