import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/buildings/buildings_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class BuildingsView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<BuildingsViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        viewModel: model,
        body: Container(
          padding: EdgeInsets.all(32),
          child: ListView.separated(
            itemCount: model.buildings.length,
            itemBuilder: (context, index) =>
                _buildingWidget(context, model, model.buildings[index]),
            separatorBuilder: (context, index) => SizedBox(height: 16),
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _buildingWidget(
      BuildContext context, BuildingsViewModel model, Building building) {
    return Container(
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(16),
        color: AstroGameColors.lightGrey,
      ),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          // Image
          FutureBuilder(
            future: model.getImageAsync(building.id),
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return ClipRRect(
                  borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(16),
                    bottomLeft: Radius.circular(16),
                    bottomRight: Radius.circular(32),
                  ),
                  child: Image(
                    image: snapshot.data,
                    height: 150,
                    fit: BoxFit.fitHeight,
                  ),
                );
              } else if (snapshot.hasError) {
                return Container();
              } else {
                return CircularProgressIndicator();
              }
            },
          ),

          Padding(
            padding: const EdgeInsets.all(16.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(building.name,
                    style: Theme.of(context).textTheme.headline2),
                Text(building.description),
              ],
            ),
          )
        ],
      ),
    );
  }
}
