import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/enums/planet_type.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/perk_selection/perk_selection_viewmodel.dart';
import 'package:astrogame_app/widgets/app_header.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class PerkSelectionView extends StatelessWidget {
  final AddPlayerSpeciesRequest _requestDto;

  PerkSelectionView(this._requestDto);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<PerkSelectionViewModel>.reactive(
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
      viewModelBuilder: () => ServiceLocator.get(param1: _requestDto),
    );
  }

  Widget _desktopView(
    BuildContext context,
    PerkSelectionViewModel model,
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
                _planetTypeSelectionWidget(context, model),
                SizedBox(width: 48),
                _perkSelectionWidget(context, model),
              ],
            ),
          ),
        ),
        _footer(context, model),
      ],
    );
  }

  Widget _planetTypeSelectionWidget(
    BuildContext context,
    PerkSelectionViewModel model,
  ) {
    return Expanded(
      child: Container(
        padding: EdgeInsets.all(16),
        decoration: BoxDecoration(
          color: AstroGameColors.mediumGrey,
          borderRadius: BorderRadius.circular(16),
        ),
        child: Column(
          children: [
            Text('Select your planet type'),
            SizedBox(height: 16),
            Expanded(
              child: Scrollbar(
                child: GridView.extent(
                  maxCrossAxisExtent: 300,
                  childAspectRatio: 4 / 3,
                  crossAxisSpacing: 16,
                  mainAxisSpacing: 16,
                  children: [
                    _planetTypeWidget(
                        model, 'planet_volcano_1.png', PlanetType.volcano),
                    _planetTypeWidget(
                        model, 'planet_desert_9.png', PlanetType.desert),
                    _planetTypeWidget(model, 'planet_continental_1.png',
                        PlanetType.continental),
                    _planetTypeWidget(
                        model, 'planet_ocean_6.png', PlanetType.ocean),
                    _planetTypeWidget(
                        model, 'planet_rock_1.png', PlanetType.rock),
                    _planetTypeWidget(
                        model, 'planet_gas_1.png', PlanetType.gas),
                    _planetTypeWidget(
                        model, 'planet_ice_3.png', PlanetType.ice),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _planetTypeWidget(
      PerkSelectionViewModel model, String imageName, PlanetType planetType) {
    return Container(
      decoration: BoxDecoration(
        gradient: (model.selectedPlanetType == planetType)
            ? LinearGradient(colors: [
                AstroGameColors.purple,
                AstroGameColors.torque,
              ])
            : LinearGradient(colors: [
                AstroGameColors.lightGrey,
                AstroGameColors.lightGrey,
              ]),
        borderRadius: BorderRadius.circular(16),
      ),
      child: InkWell(
        onTap: () => model.selectedPlanetType = planetType,
        child: Column(
          children: [
            Image.asset('assets/images/$imageName'),
            Text(PlanetTypeName[planetType]!),
            //SizedBox(height: 16),
          ],
        ),
      ),
    );
  }

  Widget _perkSelectionWidget(
    BuildContext context,
    PerkSelectionViewModel model,
  ) {
    return Expanded(
      child: Container(
        padding: EdgeInsets.all(16),
        decoration: BoxDecoration(
          color: AstroGameColors.mediumGrey,
          borderRadius: BorderRadius.circular(16),
        ),
        child: Column(
          children: [
            Text(
                '${model.countSelectedItems} of ${PerkSelectionViewModel.countMaxPerks} perks selected'),
            Expanded(
              child: ListView.builder(
                  itemCount: model.countPerks,
                  itemBuilder: (context, index) {
                    if (model.countPerks == 0) {
                      return SizedBox.shrink();
                    }

                    return _listItemWidget(context, model, index);
                  }),
            ),
          ],
        ),
      ),
    );
  }

  Widget _listItemWidget(
      BuildContext context, PerkSelectionViewModel model, int index) {
    return GestureDetector(
      onTap: () => model.trySetSelected(index),
      child: Container(
        padding: EdgeInsets.all(16),
        margin: EdgeInsets.all(8),
        decoration: BoxDecoration(
          //color: AstroGameColors.lightGrey,
          gradient: (model.isPerkSelected(index))
              ? LinearGradient(colors: [
                  AstroGameColors.purple,
                  AstroGameColors.torque,
                ])
              : LinearGradient(colors: [
                  AstroGameColors.lightGrey,
                  AstroGameColors.lightGrey,
                ]),
          borderRadius: BorderRadius.circular(16),
        ),
        child: Column(
          children: [
            Text(model.perks[index].title),
            Text(model.perks[index].description),
          ],
        ),
      ),
    );
  }

  Widget _footer(BuildContext context, PerkSelectionViewModel model) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.end,
      children: [
        Container(
          padding: EdgeInsets.only(left: 48, right: 48, bottom: 16),
          child: ElevatedButton(
            child: Text('Create Species'),
            onPressed: (model.isButtonEnabled) ? model.saveSpecies : null,
          ),
        ),
      ],
    );
  }
}
