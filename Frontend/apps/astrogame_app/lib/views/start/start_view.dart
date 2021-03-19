import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/controls/gradient_button.dart';
import 'package:astrogame_app/views/solar_system/solar_system_view.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:stacked/stacked.dart';
import 'start_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';

class StartView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<StartViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        viewModel: model,
        body: Container(
          child: Column(
            children: [
              Row(
                children: [
                  Container(
                    //height: 50,
                    width: 200,
                    child: TextFormField(
                      controller: model.solarSystemNumberController,
                      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
                    ),
                  ),
                  AstroGameGradientButton(
                    onPressed: model.loadSolarSystemAsync,
                    child: Text(
                      'Load',
                      style: Theme.of(context).textTheme.button,
                    ),
                  ),
                ],
              ),
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: InteractiveViewer(
                    constrained: false,
                    maxScale: 1,
                    minScale: 1,
                    child: SolarSystemView(),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
      viewModelBuilder: () => getIt.get(),
    );
  }
}
