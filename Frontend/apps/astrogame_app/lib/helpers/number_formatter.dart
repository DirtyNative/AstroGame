import 'package:intl/intl.dart';

class NumberFormatter {
  static NumberFormat _noDecimalsFormat = new NumberFormat('#');
  static NumberFormat _oneDecimalFormat = new NumberFormat('#.0');
  static NumberFormat _twoDecimalsFormat = new NumberFormat('#.00');

  static int _thousand = 1000;
  static int _million = 1000000;
  static int _billion = 1000000000;
  static int _trillion = 1000000000000;

  static String _thousandAbbreviation = 'K';
  static String _millionAbbreviation = 'M';
  static String _billionAbbreviation = 'B';
  static String _trillionAbbreviation = 'T';

  static String format(
    double number,
    int countDecimals, {
    bool fullNumbers = false,
  }) {
    double cut = _cut(number);
    var abbreviation = _getAbbreviation(number);
    var format = (number < 1000)
        ? (fullNumbers)
            ? _getFormat(0)
            : _getFormat(countDecimals)
        : _getFormat(countDecimals);

    return '${format.format(cut)} $abbreviation';
  }

  static double _cut(double number) {
    if (number > _trillion) {
      return number / _trillion;
    } else if (number > _billion) {
      return number / _billion;
    } else if (number > _million) {
      return number / _million;
    } else if (number > _thousand) {
      return number / _thousand;
    } else {
      return number;
    }
  }

  static String _getAbbreviation(number) {
    if (number > _trillion) {
      return _trillionAbbreviation;
    } else if (number > _billion) {
      return _billionAbbreviation;
    } else if (number > _million) {
      return _millionAbbreviation;
    } else if (number > _thousand) {
      return _thousandAbbreviation;
    } else {
      return '';
    }
  }

  static NumberFormat _getFormat(int countDecimals) {
    if (countDecimals == 2) {
      return _twoDecimalsFormat;
    } else if (countDecimals == 1) {
      return _oneDecimalFormat;
    } else {
      return _noDecimalsFormat;
    }
  }
}
