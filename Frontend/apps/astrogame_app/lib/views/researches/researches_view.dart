import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/researches/researches_viewmodel.dart';
import 'package:astrogame_app/views/researches/widgets/research_view.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';
import 'package:stacked/stacked.dart';

class ResearchesView extends StatelessWidget {
  final PageController controller = PageController();

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ResearchesViewModel>.reactive(
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
                padding: const EdgeInsets.only(left: 0, right: 0),
                child: PageView(
                  controller: controller,
                  onPageChanged: (index) => model.selectedTabIndex = index,
                  children: [
                    _listView(model.physicsResearches),
                    _listView(model.engineeringResearches),
                    _listView(model.biologyResearches),
                    _listView(model.socialResearches),
                    _listView(model.astronomyResearches),
                    _listView(model.industryResearches),
                    _listView(model.militaryResearches),
                    _listView(model.newWorldsResearches),
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

  Widget _tabWidget(ResearchesViewModel model) {
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

  Widget _listView(List<Research> researches) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 32),
      child: ListView.builder(
        itemCount: researches?.length ?? 0,
        itemBuilder: (context, index) => ResearchView(researches[index]),
      ),
    );
  }
}
