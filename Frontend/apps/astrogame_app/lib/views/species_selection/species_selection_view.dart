import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/species_selection/species_selection_viewmodel.dart';
import 'package:astrogame_app/widgets/app_header.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class SpeciesSelectionView extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _State();
}

class _State extends State<SpeciesSelectionView> with TickerProviderStateMixin {
  int selectedIndex = 0;
  var padding = EdgeInsets.symmetric(horizontal: 18, vertical: 12);
  double gap = 10;
  late TabController controller;

  @override
  void initState() {
    super.initState();
    controller = new TabController(length: 3, vsync: this);
    controller.addListener(() {});
  }

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<SpeciesSelectionViewModel>.reactive(
      builder: (context, model, _) => Scaffold(
        body: GestureDetector(
          child: Container(
            decoration: BoxDecoration(
              color: AstroGameColors.darkGrey,
            ),
            child: _desktopView(context, model),
          ),
          onTap: () => FocusScope.of(context).unfocus(),
          behavior: HitTestBehavior.opaque,
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _desktopView(
    BuildContext context,
    SpeciesSelectionViewModel model,
  ) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        AppHeader(),
        Text(
          'Create your species',
          style: Theme.of(context).textTheme.headline1,
          textAlign: TextAlign.center,
        ),
        Expanded(
          child: Container(
            padding: EdgeInsets.all(48),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                _selectedSpeciesWidget(context, model),
                SizedBox(width: 48),
                _speciesSelectionWidget(context, model),
              ],
            ),
          ),
        ),
        //_footer(),
      ],
    );
  }

  Widget _selectedSpeciesWidget(
      BuildContext context, SpeciesSelectionViewModel model) {
    return Container(
      padding: EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: AstroGameColors.mediumGrey,
        borderRadius: BorderRadius.circular(16),
      ),
      width: 500,
      child: Column(
        children: [
          // Empire name
          TextField(
            decoration: InputDecoration(hintText: 'Empire name'),
            controller: model.empireNameController,
          ),

          // Spacing
          SizedBox(height: 48),

          // Species image
          (model.selectedSpecies == null)
              ? SizedBox(height: 200)
              : FutureBuilder<ImageProvider>(
                  future: model.getImageAsync(model.selectedSpecies!.assetName),
                  builder: (context, snapshot) {
                    if (snapshot.hasData) {
                      return Image(
                        image: snapshot.data!,
                        height: 200,
                        fit: BoxFit.fitHeight,
                      );
                    } else {
                      return Container(
                          height: 200, child: CircularProgressIndicator());
                    }
                  }),

          // Spacing
          SizedBox(height: 48),

          ElevatedButton(
              child: Text('Next'),
              onPressed: model.isNextButtonEnabled
                  ? model.showPerkSelectionView
                  : null),
        ],
      ),
    );
  }

  Widget _speciesSelectionWidget(
    BuildContext context,
    SpeciesSelectionViewModel model,
  ) {
    return Expanded(
      child: Container(
        padding: EdgeInsets.all(16),
        decoration: BoxDecoration(
          color: AstroGameColors.mediumGrey,
          borderRadius: BorderRadius.circular(16),
        ),
        child: GridView.builder(
            gridDelegate: SliverGridDelegateWithMaxCrossAxisExtent(
                maxCrossAxisExtent: 300,
                childAspectRatio: 3 / 2,
                crossAxisSpacing: 16,
                mainAxisSpacing: 16),
            itemCount: model.species.length,
            itemBuilder: (context, index) {
              return Container(
                decoration: BoxDecoration(
                  color: AstroGameColors.lightGrey,
                  borderRadius: BorderRadius.circular(16),
                ),
                padding: EdgeInsets.all(8),
                child: (model.species.length == 0)
                    ? SizedBox(height: 200)
                    : FutureBuilder<ImageProvider>(
                        future:
                            model.getImageAsync(model.species[index].assetName),
                        builder: (context, snapshot) {
                          if (snapshot.hasData) {
                            return InkWell(
                              onTap: () =>
                                  model.selectedSpecies = model.species[index],
                              child: Image(
                                image: snapshot.data!,
                                height: 200,
                                fit: BoxFit.fitHeight,
                              ),
                            );
                          } else {
                            return Container(
                                height: 200,
                                child: CircularProgressIndicator());
                          }
                        }),
              );
            }),
      ),
    );
  }
}
