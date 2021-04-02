import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/controls/gradient_button.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/solar_system/solar_system_view.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:stacked/stacked.dart';
import 'start_viewmodel.dart';

class StartView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<StartViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        //viewModel: model,
        body: Container(
          color: AstroGameColors.mediumGrey,
          padding: EdgeInsets.all(32),
          child: Column(
            children: [
              Row(
                children: [
                  TextButton(
                    onPressed: model.decrement,
                    child: Text('-'),
                  ),
                  Container(
                    //height: 50,
                    width: 200,
                    child: TextField(
                      controller: model.solarSystemNumberController,
                      inputFormatters: [FilteringTextInputFormatter.digitsOnly],
                      decoration: InputDecoration(
                        hintText: 'Test',
                        prefixIcon: Icon(
                          Icons.search,
                          color: Colors.white,
                        ),
                      ),
                    ),
                  ),
                  TextButton(
                    onPressed: model.increment,
                    child: Text('+'),
                  ),
                  SizedBox(width: 16),
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
                child: Container(
                  margin: EdgeInsets.only(top: 16),
                  decoration: BoxDecoration(
                    color: AstroGameColors.lightGrey,
                    borderRadius: BorderRadius.circular(25),
                  ),
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
