import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import ProductsPage from './Components/Views/ProductsPage';
import CheckoutPage from './Components/Views/CheckoutPage';
import OrderConfirmationPage from './Components/Views/OrderConfirmationPage';

const Routes = () => (
  <Switch>
    <Route exact path='/' component={ProductsPage} />
    <Route path='/CheckoutPage/0' component={ProductsPage} />
    <Route path='/CheckoutPage/:cartId' component={CheckoutPage} />
    <Route path='/ProductsPage/:cartId' component={ProductsPage} />
    <Route path='/OrderConfirmationPage/' component={OrderConfirmationPage} />
  </Switch>
);

export default Routes;
