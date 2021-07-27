// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'element.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Element _$ElementFromJson(Map<String, dynamic> json) {
  return Element()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..name = json['name'] as String
    ..naturalOccurrenceWeight = json['naturalOccurrenceWeight'] as int
    ..stellarObjectResources = (json['stellarObjectResources']
            as List<dynamic>?)
        ?.map((e) => StellarObjectResource.fromJson(e as Map<String, dynamic>))
        .toList()
    ..symbol = json['symbol'] as String
    ..type = _$enumDecode(_$ElementTypeEnumMap, json['type']);
}

Map<String, dynamic> _$ElementToJson(Element instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'naturalOccurrenceWeight': instance.naturalOccurrenceWeight,
      'stellarObjectResources': instance.stellarObjectResources,
      'symbol': instance.symbol,
      'type': _$ElementTypeEnumMap[instance.type],
    };

K _$enumDecode<K, V>(
  Map<K, V> enumValues,
  Object? source, {
  K? unknownValue,
}) {
  if (source == null) {
    throw ArgumentError(
      'A value must be provided. Supported values: '
      '${enumValues.values.join(', ')}',
    );
  }

  return enumValues.entries.singleWhere(
    (e) => e.value == source,
    orElse: () {
      if (unknownValue == null) {
        throw ArgumentError(
          '`$source` is not one of the supported values: '
          '${enumValues.values.join(', ')}',
        );
      }
      return MapEntry(unknownValue, enumValues.values.first);
    },
  ).key;
}

const _$ElementTypeEnumMap = {
  ElementType.gases: 0,
  ElementType.metals: 1,
};
