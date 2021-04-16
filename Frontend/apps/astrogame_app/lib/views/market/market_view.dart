import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/views/market/market_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class MarketView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<MarketViewModel>.reactive(
      builder: (context, model, _) => Container(),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }
}
