import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/species_selection/species_selection_viewmodel.dart';
import 'package:astrogame_app/widgets/app_header.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';
import 'package:stacked/stacked.dart';

class SpeciesSelectionView extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _State();
}

class _State extends State<SpeciesSelectionView> with TickerProviderStateMixin {
  int selectedIndex = 0;
  var padding = EdgeInsets.symmetric(horizontal: 18, vertical: 12);
  double gap = 10;
  TabController controller;

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
              color: AstroGameColors.mediumGrey,
              image: DecorationImage(
                  image: AssetImage('assets/images/background_2.png'),
                  fit: BoxFit.cover),
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
      children: [
        AppHeader(),
        _tabBar(),
        Container(
          height: 300,
          padding: EdgeInsets.all(48),
          child: Expanded(
            child: TabBarView(
              controller: controller,
              children: [
                _speciesSelectionWidget(context, model),
                _planetTypeSelectonWidget(context, model),
                _perkSelectionWidget(context, model),
              ],
            ),
          ),
        ),
      ],
    );
  }

  Widget _speciesSelectionWidget(
    BuildContext context,
    SpeciesSelectionViewModel model,
  ) {
    return Container(
      padding: EdgeInsets.all(24),
      decoration: BoxDecoration(
        color: AstroGameColors.mediumGrey,
        borderRadius: BorderRadius.circular(16),
      ),
      child: Column(
        children: [
          Text(
            'Create your species',
            style: Theme.of(context).textTheme.headline2,
          )
        ],
      ),
    );
  }

  Widget _planetTypeSelectonWidget(
    BuildContext context,
    SpeciesSelectionViewModel model,
  ) {
    return Container(
      padding: EdgeInsets.all(24),
      child: Column(
        children: [
          Text(
            'Select your starter planet type',
            style: Theme.of(context).textTheme.headline2,
          ),
        ],
      ),
    );
  }

  Widget _perkSelectionWidget(
    BuildContext context,
    SpeciesSelectionViewModel model,
  ) {
    return Container();
  }

  Widget _tabBar() {
    return Container(
      margin: EdgeInsets.symmetric(horizontal: 20, vertical: 5),
      decoration: BoxDecoration(
        color: Colors.red,
        borderRadius: BorderRadius.all(
          Radius.circular(100),
        ),
      ),
      child: GNav(
          mainAxisAlignment: MainAxisAlignment.center,
          tabs: [
            GButton(
              gap: gap,
              //iconActiveColor: Colors.purple,
              iconColor: Colors.white,
              textColor: Colors.white,
              backgroundGradient: LinearGradient(colors: [
                AstroGameColors.purple,
                AstroGameColors.torque,
              ]),
              iconSize: 24,
              padding: padding,
              icon: Icons.home,
              text: 'Home',
            ),
            GButton(
              gap: gap,
              backgroundGradient: LinearGradient(colors: [
                AstroGameColors.purple,
                AstroGameColors.torque,
              ]),
              iconSize: 24,
              padding: padding,
              icon: Icons.hearing_outlined,
              text: 'Likes',
            ),
            GButton(
              gap: gap,
              backgroundGradient: LinearGradient(colors: [
                AstroGameColors.purple,
                AstroGameColors.torque,
              ]),
              iconSize: 24,
              padding: padding,
              icon: Icons.search,
              text: 'Search',
            ),
          ],
          selectedIndex: selectedIndex,
          onTabChange: (index) {
            controller.index = index;
          }),
    );
  }
}
