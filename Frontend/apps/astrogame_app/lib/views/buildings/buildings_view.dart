import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/buildings/buildings_viewmodel.dart';
import 'package:astrogame_app/views/technologies/technologies_view.dart';
import 'package:astrogame_app/views/technologies/technologies_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';

class BuildingsView extends TechnologiesView<BuildingsViewModel> {
  @override
  Widget pageView(TechnologiesViewModel model) {
    return PageView(
      controller: controller,
      onPageChanged: (index) => model.selectedTabIndex = index,
      children: [
        listView((model as BuildingsViewModel).conveyorBuildings),
        listView(model.civilBuildings),
        listView(model.refineryBuildings),
        listView(model.manufacturingFacilityBuildings),
        listView(model.researchLaboratoryBuildings),
        listView(model.storageBuildings),
      ],
    );
  }

  @override
  Widget tabWidget(TechnologiesViewModel model) {
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
}
