import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/home/widgets/construction_view.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';
import 'constructions_viewmodel.dart';
import 'package:astrogame_app/models/technologies/stellar_object_dependent_technology_upgrade.dart';

class ConstructionsView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.all(32),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(16),
        color: AstroGameColors.lightGrey,
      ),
      child: Column(
        children: [
          Padding(
            padding: const EdgeInsets.only(top: 16, bottom: 8),
            child: Text('Constructions in progress',
                style: Theme.of(context).textTheme.headline2),
          ),
          ViewModelBuilder<ConstructionsViewModel>.reactive(
            builder: (context, model, _) => ListView.separated(
              shrinkWrap: true,
              itemBuilder: (context, index) => (model.technologyUpgrades[index]
                      is StellarObjectDependentTechnologyUpgrade)
                  ? ConstructionView(model.technologyUpgrades[index]
                      as StellarObjectDependentTechnologyUpgrade)
                  : SizedBox.shrink(),
              separatorBuilder: (context, index) => SizedBox(height: 8),
              itemCount: model.technologyUpgrades.length,
            ),
            viewModelBuilder: () => ServiceLocator.get(),
          ),
        ],
      ),
    );
  }
}
