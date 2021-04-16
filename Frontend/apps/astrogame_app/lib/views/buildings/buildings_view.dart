import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/buildings/buildings_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';
import 'package:stacked/stacked.dart';

import 'widgets/building_view.dart';

class BuildingsView extends StatelessWidget {
  final PageController controller = PageController();

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<BuildingsViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Column(
          children: [
            Padding(
              padding: const EdgeInsets.only(left: 32, right: 32, top: 32),
              child: _tabWidget(model),
            ),
            Divider(color: Colors.white),
            Expanded(
              child: Padding(
                padding: const EdgeInsets.all(32.0),
                child: PageView(
                  controller: controller,
                  onPageChanged: (index) => model.selectedTabIndex = index,
                  children: [
                    _listView(model.conveyorBuildings),
                    _listView(model.civilBuildings),
                    _listView(model.refineryBuildings),
                    _listView(model.manufacturingFacilityBuildings),
                    _listView(model.researchLaboratoryBuildings),
                    _listView(model.storageBuildings),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _tabWidget(BuildingsViewModel model) {
    return Container(
      child: GNav(
        selectedIndex: model.selectedTabIndex,
        padding: EdgeInsets.all(10),
        gap: 8,
        iconSize: 24,
        color: Colors.white,
        tabBackgroundGradient: LinearGradient(colors: [
          AstroGameColors.purple,
          AstroGameColors.torque,
        ]),
        activeColor: Colors.white,
        textStyle: TextStyle(color: Colors.white),
        tabs: [
          GButton(
            icon: Icons.science_outlined,
            text: 'Conveyor',
          ),
          GButton(
            icon: Icons.home,
            text: 'Civil',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Refinery',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Manufacturing facility',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Research laboratory',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'storage',
          ),
        ],
        onTabChange: (index) {
          model.selectedTabIndex = index;
          controller.jumpToPage(index);
        },
      ),
    );
  }

  Widget _listView(List<Building> buildings) {
    return Scrollbar(
      child: ListView.separated(
        itemCount: buildings?.length ?? 0,
        itemBuilder: (context, index) => BuildingView(buildings[index]),
        separatorBuilder: (context, index) => SizedBox(height: 16),
      ),
    );
  }
}
