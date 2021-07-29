import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/researches/researches_viewmodel.dart';
import 'package:astrogame_app/views/technologies/technologies_view.dart';
import 'package:astrogame_app/views/technologies/technologies_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';

class ResearchesView extends TechnologiesView<ResearchesViewModel> {
  @override
  Widget pageView(TechnologiesViewModel model) {
    return PageView(
      controller: controller,
      onPageChanged: (index) => model.selectedTabIndex = index,
      children: [
        listView((model as ResearchesViewModel).physicsResearches),
        listView(model.engineeringResearches),
        listView(model.biologyResearches),
        listView(model.socialResearches),
        listView(model.astronomyResearches),
        listView(model.industryResearches),
        listView(model.militaryResearches),
        listView(model.newWorldsResearches),
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
            text: 'Physics',
          ),
          GButton(
            icon: Icons.home,
            text: 'Engineering',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Biology',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Social',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Astronomy',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Industry',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Military',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'NewWorlds',
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
